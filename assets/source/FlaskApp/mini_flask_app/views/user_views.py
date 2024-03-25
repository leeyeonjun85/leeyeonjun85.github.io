import os
import csv
import json

from flask import Blueprint, request
from mini_flask_app import CSV_FILEPATH, TMP_FILEPATH

user_bp = Blueprint('user', __name__)

@user_bp.route('/user')
def get_user():
    if (username := request.args.get('username', None)) is None:
        return 'No username given', 400

    user = None

    with open(CSV_FILEPATH, 'r') as f:
        csv_reader = csv.DictReader(f)

        for row in csv_reader:
            if row['username'] == username:
                user = row
    
    if user is None:
        return f"User '{username}' doesn't exist", 404

    return str(user['id']), 200


@user_bp.route('/user', methods=['PATCH'])
def update_user():
    username = request.args.get('username', None)
    new_username = request.args.get('new_username', None)
    print(f"✅ username : {username}")
    print(f"✅ new_username : {new_username}")
    if not username or not new_username:
        return "No username/new_username given", 400 

    # 새로운 이름이 사용중인지 확인
    user = None
    new_user = None
    with open(CSV_FILEPATH, 'r') as f:
        csv_reader = csv.DictReader(f)

        for row in csv_reader:
            if row['username'] == username:
                user = row

            if row['username'] == new_username:
                new_user = row

    if not user:
        return f"User '{username}' doesn't exist", 400

    if new_user:
        return f"Username '{new_username}' is in use", 400


    with open(CSV_FILEPATH, 'r') as inFile, open(TMP_FILEPATH, 'w', newline='') as outFile:
        fieldnames = ['id', 'username']
        csv_reader = csv.DictReader(inFile)
        csv_writer = csv.DictWriter(outFile, fieldnames=fieldnames)
        
        csv_writer.writeheader()

        for row in csv_reader:
            id_match = row['id'] == user['id']
            username_match = row['username'] == user['username']

            if id_match and username_match:
                row['username'] = new_username

            csv_writer.writerow(row)

        inFile.close()
        outFile.close()
        
        os.remove(CSV_FILEPATH)
        os.rename(TMP_FILEPATH, CSV_FILEPATH)

    return 'OK', 200

    

@user_bp.route('/user', methods=['POST'])
def create_user():

    body = request.get_json()

    print(f"✅ body : {body}")

    try:
        username = body['username']
    except TypeError as e:
        return "No username given", 400

    # 같은 이름이 있는지 확인
    user = None
    with open(CSV_FILEPATH, 'r') as inFile:
        csv_reader = csv.DictReader(inFile)

        for row in csv_reader:
            if row['username'] == username:
                user = row
                break

    if user:
        return f"User '{username}' already exists", 400

    #
    with open(CSV_FILEPATH, 'r') as inFile, open(TMP_FILEPATH, 'w', newline='') as outFile:
        fieldnames = ['id', 'username']

        csv_reader = csv.DictReader(inFile)
        csv_writer = csv.DictWriter(outFile, fieldnames=fieldnames)

        csv_writer.writeheader()

        last_id_num = 0
        for row in csv_reader:
            last_id_num = row['id']
            csv_writer.writerow(row)

        csv_writer.writerow({
            'id':int(last_id_num) + 1,
            'username':username
        })

        inFile.close()
        outFile.close()

        os.remove(CSV_FILEPATH)
        os.rename(TMP_FILEPATH, CSV_FILEPATH)

    return f"Created user '{username}'", 200

@user_bp.route('/user', methods=['DELETE'])
def delete_user():
    """
    delete_user 함수는 `username` 을 키로 한 값을 
    쿼리 파라미터 값으로 넘겨주면 해당 값을 가진 
    유저를 'users.csv' 파일에서 제거해야 합니다.

    요구사항:
      - HTTP Method: `DELETE`
      - Endpoint: `api/user`

    상황별 요구사항:
      - `username` 값이 주어지지 않은 경우:
        - 리턴 값: "No username given"
        - HTTP 상태 코드: `400`
      - `username` 이 주어졌지만 해당되는 유저가 없는 경우:
        - 리턴 값: "User '{ username }' doesn't exist"
        - HTTP 상태 코드: `404`
      - 주어진 `username` 값을 가진 유저를 정상적으로 삭제한 경우:
        - 리턴 값: "OK"
        - HTTP 상태 코드: `200`
    """
    username = request.args.get('username', None)

    if not username:
        return "No username given", 400

    user = None
    with open(CSV_FILEPATH, 'r') as inFile:
        csv_reader = csv.DictReader(inFile)

        for row in csv_reader:
            if row['username'] == username:
                user = row
                break

    if not user:
        return f"User '{username}' doesn't exist", 404

    with open(CSV_FILEPATH, 'r') as inFile, open(TMP_FILEPATH, 'w', newline='') as outFile:
        fieldnames = ['id', 'username']

        csv_reader = csv.DictReader(inFile)
        csv_writer = csv.DictWriter(outFile, fieldnames=fieldnames)

        csv_writer.writeheader()

        for row in csv_reader:
            id_match = row['id'] == user['id']
            username_match = row['username'] == user['username']

            if id_match and username_match:
                continue

            csv_writer.writerow(row)

        inFile.close()
        outFile.close()

        os.remove(CSV_FILEPATH)
        os.rename(TMP_FILEPATH, CSV_FILEPATH)

    return 'OK', 200
