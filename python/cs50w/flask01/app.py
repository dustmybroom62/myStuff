from flask import Flask, render_template, request
import json

app = Flask(__name__)

@app.route("/")
def index():
    return render_template("index.html", name="world")

@app.route("/<string:name>")
def hello(name):
    name = name.capitalize()
    return render_template("index.html", name=name)

@app.route("/api/<int:id>", methods=["GET"])
def get(id):
    return Flask.make_response(app, {"id": id, "name": f"number{id}"})

@app.route("/api", methods=["POST"])
def post():
    if request.content_type != "application/json":
        return request.content_type
        
    rdata = request.data
    jd = json.loads(rdata)
    for f in jd:
        jd[f] += 5
    return Flask.make_response(app, jd)

