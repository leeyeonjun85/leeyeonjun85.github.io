from flask import Flask, jsonify, request
from flask_restx import Resource, Api

from PIL import Image
import matplotlib.pyplot as plt
from paddleocr import PaddleOCR, draw_ocr
import io

app = Flask(__name__)
api = Api(app)


@api.route('/TestOCR')
class TestOCR(Resource):
    def post(self):
        
        
        # print("✅✅1")
        # image_data = request.data
        print("✅✅2")
        image_data = request.files['image1']
        print("✅✅3")
        print(image_data)
        print("✅✅4")
        print(image_data.stream)
        print("✅✅5")
        image1 = Image.open(image_data.stream).convert('RGB')
        # imgplot = plt.imshow(image1)
        # plt.show()
        # print("✅✅6")  
        buffer = io.BytesIO()
        image1.save(buffer, format='png', quality=100)
        byteArray = buffer.getvalue()
           
        ocr = PaddleOCR(use_angle_cls=True, lang='en')
        print("✅✅7")
        result = ocr.ocr(byteArray, cls=True)
        print("✅✅8")
        
        # for idx in range(len(result)):
        #     res = result[idx]
        #     for line in res:
        #         print(line)
        #         resultList.append(line)

        # result0 = result[0]
        # print("✅1")
        # boxes = [line[0] for line in result0]
        # print("✅2")
        # txts = [line[1][0] for line in result0]
        # print("✅3")
        # scores = [line[1][1] for line in result0]
        # print("✅4")
        # # im_show = draw_ocr(img, boxes, txts, scores, font_path='./doc/fonts/latin.ttf')
        # print("✅5")
        # # im_show_image = Image.fromarray(im_show)
        # print("✅6")

        # # todos[idx] = request.json.get('data')
        # return {
        #     'result' : result,
        #     'resultList': resultList,
        #     'result0':result0,
        #     'boxes':boxes,
        #     'txts':txts,
        #     'scores':scores
        # }






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
    app.run(debug=True, host='0.0.0.0', port=80)