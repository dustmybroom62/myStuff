using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBB.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreBB.Web.Controllers
{

	[Authorize]
	public class TopicController : Controller
	{
		private CoreBBContext _dbContext;
		public TopicController(CoreBBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult Index(int forumId)
		{
			var forum = _dbContext.Forum.Include("Owner").SingleOrDefault(f => f.Id == forumId);
			if (forum == null)
			{
				throw new Exception("Forum does not exist.");
			}

			forum.Topic = _dbContext.Topic.Include("Owner")
				.Where(t => t.ForumId == forumId && t.ReplyToTopicId == null).ToList();
			return View(forum);
		}

		[HttpGet]
		public IActionResult Create(int forumId)
		{
			var forum = _dbContext.Forum.SingleOrDefault(f => f.Id == forumId);
			if (forum == null)
			{
				throw new Exception("Forum does not exist.");
			}

			if (forum.IsLocked)
			{
				throw new Exception("This forum is locked.");
			}

			var topic = new Topic { ForumId = forumId };
			return View(topic);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Topic model)
		{
			if (!ModelState.IsValid)
			{
				throw new Exception("Invalid topic information.");
			}

			var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
			model.OwnerId = user.Id;
			model.PostDateTime = DateTime.UtcNow;
			await _dbContext.Topic.AddAsync(model);
			await _dbContext.SaveChangesAsync();
			model.RootTopicId = model.Id;
			_dbContext.Topic.Update(model);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction("Index", new { forumId = model.ForumId });
		}

		private ICollection<Topic> GetTopicChildren(ICollection<Topic> allTopics, Topic topic)
		{
			//base case
			if (allTopics.All(b => b.ReplyToTopicId != topic.Id)) return new List<Topic>();

			//recursive case
			topic.InverseReplyToTopic = allTopics
				.Where(b => b.ReplyToTopicId == topic.Id)
				.ToList();

			foreach (var item in topic.InverseReplyToTopic)
			{
				item.InverseReplyToTopic = GetTopicChildren(allTopics, item);
			}

			return topic.InverseReplyToTopic;
		}

		[HttpGet]
		public IActionResult Detail(int id)
		{
			var rootTopic = _dbContext.Topic.Include("Owner").Include("ModifiedByUser")
				.SingleOrDefault(t => t.Id == id);
			if (rootTopic == null)
			{
				throw new Exception("Topic does not exist.");
			}

			ICollection<Topic> children = _dbContext.Topic.Include("Owner").Include("ModifiedByUser")
				.Where(t => t.RootTopicId == rootTopic.Id && t.ReplyToTopicId != null)
				.ToList();

			rootTopic.InverseReplyToTopic = GetTopicChildren(children, rootTopic);
			return View(rootTopic);
		}

		[HttpGet]
		public IActionResult Reply(int toId)
		{
			var toTopic = _dbContext.Topic.SingleOrDefault(t => t.Id == toId);
			if (toTopic == null)
			{
				throw new Exception("The topic does not exist.");
			}

			if (toTopic.IsLocked)
			{
				throw new Exception("The topic is locked.");
			}

			var topic = new Topic
			{
				ReplyToTopicId = toTopic.Id,
				RootTopicId = toTopic.RootTopicId,
				ForumId = toTopic.ForumId,
				ReplyToTopic = toTopic
			};

			return View(topic);
		}

		[HttpPost]
		public async Task<IActionResult> Reply(Topic model)
		{
			if (!ModelState.IsValid)
			{
				throw new Exception("Invalid topic information.");
			}

			var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
			model.OwnerId = user.Id;
			model.PostDateTime = DateTime.UtcNow;
			await _dbContext.Topic.AddAsync(model);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction("Detail", new { id = model.RootTopicId });
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var topic = _dbContext.Topic.Include("Owner").Include("ModifiedByUser")
				.SingleOrDefault(t => t.Id == id);
			if (topic == null)
			{
				throw new Exception("Topic does not exist.");
			}

			var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
			if (!(topic.OwnerId == user.Id || User.IsInRole(Roles.Administrator)))
			{
				throw new Exception("Update topic denied.");
			}

			return View(topic);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Topic model)
		{
			if (!ModelState.IsValid)
			{
				throw new Exception("Invalid topic information.");
			}

			var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
			model.ModifiedByUserId = user.Id;
			model.ModifyDateTime = DateTime.UtcNow;
			_dbContext.Topic.Update(model);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction("Detail", new { id = model.RootTopicId });
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var topic = _dbContext.Topic.SingleOrDefault(t => t.Id == id);
			if (topic == null)
			{
				throw new Exception("Topic does not exist.");
			}

			var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
			if (!(topic.OwnerId == user.Id || User.IsInRole(Roles.Administrator)))
			{
				throw new Exception("You are not authorized to delete this topic.");
			}

			return View(topic);
		}

		private void RemoveDescendants(Topic topic)
		{
			var descendants = _dbContext.Topic.Where(t => t.RootTopicId == topic.RootTopicId
			&& null != t.ReplyToTopicId
			&& t.ReplyToTopicId.Value == topic.Id);
			foreach (Topic d in descendants)
			{
				RemoveDescendants(d);
			}
			_dbContext.Topic.RemoveRange(descendants);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Topic model)
		{
			if (!ModelState.IsValid)
			{
				ViewData["Message"] = "Delete Faild: Invalid topic information.";
				//throw new Exception("Invalid topic information.");
				return RedirectToAction("Detail", new { id = model.RootTopicId });
			}

			var topic = _dbContext.Topic.SingleOrDefault(t => t.Id == model.Id);
			if (topic == null)
			{
				ViewData["Message"] = "Delete Faild: Topic does not exist.";
				//throw new Exception("Topic does not exist.");
				return RedirectToAction("Detail", new { id = model.RootTopicId });
			}

			var user = _dbContext.User.SingleOrDefault(u => u.Name == User.Identity.Name);
			if (!(topic.OwnerId == user.Id || User.IsInRole(Roles.Administrator)))
			{
				ViewData["Message"] = "You are not authorized to delete this topic.";
				//throw new Exception("You are not authorized to delete this topic.");
				return RedirectToAction("Detail", new { id = topic.RootTopicId });
			}

			var rootTopicId = topic.RootTopicId;
			var forumId = topic.ForumId;
			bool returnToForum = false;
			if (topic.Id == topic.RootTopicId)
			{
				returnToForum = true;
				var descendants = _dbContext.Topic.Where(t => null != t.ReplyToTopic && t.RootTopicId == topic.Id);
				_dbContext.Topic.RemoveRange(descendants);
			} else
			{
				var descendants = _dbContext.Topic.Where(t => t.RootTopicId == topic.RootTopicId 
				&& null != t.ReplyToTopicId
				&& t.ReplyToTopicId.Value == topic.Id);
				_dbContext.Topic.RemoveRange(descendants);
			}
			_dbContext.Topic.Remove(topic);

			await _dbContext.SaveChangesAsync();

			if (returnToForum)
			{
				return RedirectToAction("Index", new { forumId = forumId });
			}
			return RedirectToAction("Detail", new { id = rootTopicId });
		}
	}
}