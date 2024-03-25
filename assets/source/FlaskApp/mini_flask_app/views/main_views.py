import csv

from flask import Blueprint, render_template
from mini_flask_app import CSV_FILEPATH

main_bp = Blueprint('main', __name__)


@main_bp.route('/')
def index():
    users = []

    with open(CSV_FILEPATH, 'r') as f:
        csv_reader = csv.DictReader(f)

        for row in csv_reader:
            print(row)
            users.append(row)

    return render_template('index.html', user_list=users)
