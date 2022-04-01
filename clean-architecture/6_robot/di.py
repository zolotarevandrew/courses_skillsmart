from robot import CleanerImpl, Cleaner
from logger import CleanerLoggerImpl, CleanerLogger

def createLogger() -> CleanerLogger:
    logger = CleanerLoggerImpl()
    return logger

def createCleaner() -> Cleaner:
    cleaner = CleanerImpl(createLogger())
    return cleaner 