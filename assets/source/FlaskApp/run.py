from mini_flask_app import create_app

app = create_app()

# if __name__ == "__main__":
#     app.run(debug=True)

if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=6714)

# app.run(debug=True)