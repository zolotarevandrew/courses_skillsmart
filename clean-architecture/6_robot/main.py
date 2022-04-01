from di import createCleaner

if __name__ == '__main__':
    cleaner = createCleaner()
    print('please enter robot commands: move, turn, set, start, stop')
    while(True):
        inputStr = input()
        cleaner.executeCommand(inputStr)

