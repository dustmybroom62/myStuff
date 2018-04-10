require "sinatra/base"
require "json"

class Web < Sinatra::Base
  get "/" do
    %{
      <style>
      h1, h2, p {
          font-family: Helvetica, Arial, sans-serif;
      }
      </style>
      <h1>Congratulations on pushing your first Cloud Foundry App</h1>
      <h2><a href="/env.json">Click here to check the ENV out</a></h2>
    }
  end

  get "/env.json" do
    content_type "application/json"
    JSON.pretty_generate(ENV.to_h)
  end

  get "/crashme" do
    STDERR.puts "I regret I have but one process to give"
    Process.exit!(0)
  end

  get "/whoami" do
    "Hi!  I'm the process on #{ENV["CF_INSTANCE_ADDR"]}.  Nice to meet you!\n"
  end
end

run Web.new
