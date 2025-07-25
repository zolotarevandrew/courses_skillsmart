from di import createCleaner
from robot import Angle, CleaningDevice, Distance, CleaningDeviceType

if __name__ == '__main__':
     cleaner = (
        createCleaner()
        .move(Distance(100))
        .turn(Angle(-90))
        .setDevice(CleaningDevice(CleaningDeviceType.SOAP))
        .move(Distance(50))
        .stop()
    )



