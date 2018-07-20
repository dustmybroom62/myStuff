const classNames = {
  TODO_ITEM: 'todo-container',
  TODO_CHECKBOX: 'todo-checkbox',
  TODO_TEXT: 'todo-text',
  TODO_DELETE: 'todo-delete',
};

//alert('loading script');

const list = document.getElementById('todo-list');
const itemCountSpan = document.getElementById('item-count');
const uncheckedCountSpan = document.getElementById('unchecked-count');

const counts = {
  item: 0,
  unchecked: 0
}

function newTodo() {
  let newItemText = prompt("Enter name of new ToDo item:");
  if (!newItemText) return;

  let newItem = list.appendChild(document.createElement("li"));
   newItem.className = classNames.TODO_ITEM;
  let newBtn = newItem.appendChild(document.createElement("button"));
  newBtn.onclick = deleteItem;
  newBtn.className = classNames.TODO_DELETE;
  newBtn.innerText = "X";
  let newChk = newItem.appendChild(document.createElement("input"));
  newChk.setAttribute("type", "checkbox");
  newChk.setAttribute("onclick", "check(this)");
  newChk.className = classNames.TODO_CHECKBOX;
  let newSpan = newItem.appendChild(document.createElement("span"));
  newSpan.innerText = newItemText;
  newSpan.className = classNames.TODO_TEXT;

  counts.item++;
  counts.unchecked++;

  updateCountDisplay();

}

function updateCountDisplay() {
  itemCountSpan.innerText = counts.item;
  uncheckedCountSpan.innerText = counts.unchecked;
}

function check(el) {
  let p = el.parentNode;
  if (el.checked) {
    counts.unchecked--;
    p.setAttribute("isChecked", "true");
  } else {
    counts.unchecked++;
    p.setAttribute("isChecked", "");
  }
  updateCountDisplay();
}

function deleteItem(ev) {
  let el = this.parentNode;
  if (!el.getAttribute("isChecked")) {
    counts.unchecked--;
  }
  list.removeChild(el);
  counts.item--;
  updateCountDisplay();
}