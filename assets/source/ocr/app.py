from flask import Flask, jsonify, request
from flask_restx import Resource, Api

from PIL import Image
import matplotlib.pyplot as plt
from paddleocr import PaddleOCR, draw_ocr
import io
import datetime as dt
import base64

app = Flask(__name__)
api = Api(app)


@api.route('/TestOCR')
class TestOCR(Resource):
    def post(self):
        # 디버깅모드 = 1
        debugMode = 0
        
        if debugMode:
            print(f"✅✅ {dt.datetime.now():%Y-%m-%d %H:%M:%S} : 시작 ✅✅")
        # image_data = request.data
        image_data = request.files['image1']
        if debugMode:
            print(f"✅✅ {dt.datetime.now():%Y-%m-%d %H:%M:%S} : 파일 ✅✅")
        image1 = Image.open(image_data.stream).convert('RGB')
        
        # 이미지 확인용
        # imgplot = plt.imshow(image1)
        # plt.show()

        # 이미지를 배열로 변환
        buffer = io.BytesIO()
        image1.save(buffer, format='png', quality=100)
        byteArray = buffer.getvalue()
        if debugMode:
            print(f"✅✅ {dt.datetime.now():%Y-%m-%d %H:%M:%S} : 이미지 배열 변환 ✅✅")
            
        # OCR
        ocr = PaddleOCR(use_angle_cls=True, lang='en')
        result = ocr.ocr(byteArray, cls=True)
        if debugMode:
            print(f"✅✅ {dt.datetime.now():%Y-%m-%d %H:%M:%S} : OCR완료 ✅✅")
        
        # 각종 데이터 저장
        result0 = result[0]
        boxes = [line[0] for line in result0]
        txts = [line[1][0] for line in result0]
        scores = [line[1][1] for line in result0]
        ocr_img_array = draw_ocr(image1, boxes, txts, scores, font_path='./doc/fonts/latin.ttf')
        ocr_img = Image.fromarray(ocr_img_array)
        
        # OCR된 이미지를 반환하기 위하여 utf-8 인코딩
        buffer = io.BytesIO()
        ocr_img.save(buffer, format='png', quality=100)
        encoded_string = base64.b64encode(buffer.getvalue()).decode('utf-8')
        
        # OCR된 이미지 확인용
        # imgplot = plt.imshow(ocr_img)
        # plt.show()
        if debugMode:
            print(f"✅✅ {dt.datetime.now():%Y-%m-%d %H:%M:%S} : OCR이미지 확인 ✅✅")


        return jsonify({
                'result' : result,
                'result0':result0,
                'boxes':boxes,
                'txts':txts,
                'scores':scores,
                'ocrEncodedString':encoded_string
            })






todos = {}
count = 1


@api.route('/todos')
class TodoPost(Resource):
    def post(self):
        global count
        global todos
        
        idx = count
        count += 1
        todos[idx] = request.json.get('data')
        
        return {
            'todo_id': idx,
            'data': todos[idx]
        }


@api.route('/todos/<int:todo_id>')
class TodoSimple(Resource):
    def get(self, todo_id):
        return {
            'todo_id': todo_id,
            'data': todos[todo_id]
        }

    def put(self, todo_id):
        todos[todo_id] = request.json.get('data')
        return {
            'todo_id': todo_id,
            'data': todos[todo_id]
        }
    
    def delete(self, todo_id):
        del todos[todo_id]
        return {
            "delete" : "success"
        }

if __name__ == "__main__":
    app.run(debug=True, host='127.0.0.1', port=6714)