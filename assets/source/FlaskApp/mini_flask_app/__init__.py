import os
from flask import Flask

CSV_FILEPATH = os.path.join(os.getcwd(), 'db', 'users.csv') 
TMP_FILEPATH = os.path.join(os.getcwd(), 'db', 'tmp.csv') 

def create_app(config=None):
    app = Flask(__name__)
    
    # 작업폴더 변경
    os.chdir(os.path.dirname(__file__))
    
    from mini_flask_app.views.main_views import main_bp
    from mini_flask_app.views.user_views import user_bp

    app.register_blueprint(main_bp)
    app.register_blueprint(user_bp, url_prefix='/api')

    return app
