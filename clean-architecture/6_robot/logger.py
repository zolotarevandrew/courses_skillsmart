class CleanerLogger(object):
    def log(self, value: str):
        pass

class CleanerLoggerImpl(CleanerLogger):
    def log(self, value: str):
        print(value)