from flask import Flask, request, jsonify
from pure_robot import createDefaultState, make;

app = Flask(__name__)

state = createDefaultState()
apiMessage = None

def transfer_to_api(message):
    global apiMessage
    apiMessage = jsonify({
        'result': message
    })

@app.route('/robot/execute', methods=['POST'])
def runCommand():
    global state
    state = make(transfer_to_api, (str(request.data.decode("utf-8"))), state)
    return apiMessage

if __name__ == '__main__':
    app.run()