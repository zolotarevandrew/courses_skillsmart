# 1) Комментарии
# Для encode_point пришлось в голове и в блокноте подебажить, было сходу непонятно посмотрев на тесты, что получается условный рекурсивный тип, но затем все встало на свои места.
# Остальные методы уже используются этой функцией, либо совсем простые.
# Не сразу понял, что из одной базовой точки можно сделать n принципиально разных обходов поверхности.
# А также, что будет происходить в результате trans loop-ов из 2-ух разных направлений - просто обходим 2 loop-а, а encode позволяет смотреть на свойства таких петель (классификация)

# 2 - Расширение тестов 

from dataclasses import dataclass
from enum import Enum
from typing import TypeAlias

from core.dependent_types import Pi, Sigma

class Matrix:
    def __init__(self, type, n: int, m: int):
        self.type = type
        self.n = n
        self.m = m

    def asList(self) -> list:
        return [self.type()] * (self.n * self.m)
    
class VectorType:
    def __init__(self, type, n):
        self.type = type
        self.n = n

class Vector:
    def __init__(self, items: list, type: VectorType):
        if len(items) != type.n:
            raise ValueError(f"Vector must have length {type.n}")
        if not all(isinstance(item, type.type) for item in items):
            raise ValueError(f"Vector must have type {type.type}")
        self.type = type
        self.items = items

matrix_to_vector = Pi(
    domain=Matrix,
    # тут надо как-то еще проверять codomain, не совсем в рамках реализованного Pi получилось
    codomain=lambda m: VectorType(m.type, m.m * m.n),
    function=lambda m: Vector(m.as_list(), VectorType(m.type, m.m * m.n))
)

vector = matrix_to_vector(Matrix(2,2))
assert len(vector.items) == 4, "Вектор должен содержать 4 элемента"


# adult min age >= 18 

class Age:
    def __init__(self, value):
        self.value = value
class AdultAge:
    def __init__(self, age: Age):
        if age.value < 18:
            raise ValueError(f"Age should be at least 18")
        self.age = age

adult_min_age = Sigma(
    domain=Age,
    codomain=lambda ag: AdultAge,
    first=Age(18),
    second=AdultAge(Age(18))
)

# 3 - примеры посложнее

# Pi-тип — на основе которого можно построить типобезопасный умный CommandHandler - обработчик и ожидаемый тип результата зависят от входной команды.

class PaymentType(Enum):
    CARD = "card"
    CASH = "cash"
    CRYPTO = "crypto"

class PaymentCommand:
    def __init__(self, payment_type: PaymentType, amount: float):
        self.payment_type = payment_type
        self.amount = amount

class CardPaymentResult:
    pass

class CashPaymentResult:
    pass

class CryptoPaymentResult:
    pass

payment_handler = Pi(
    domain=PaymentCommand,

    codomain=lambda command: {
        PaymentType.CARD: CardPaymentResult,
        PaymentType.CASH: CashPaymentResult,
        PaymentType.CRYPTO: CryptoPaymentResult,
    }[command.payment_type],

    function=lambda command: route_payment(command)
)

# Sigma-тип - цепочка инвариантов системы User -> VerifiedUser -> PaidOrder<VerifiedUser>

@dataclass(frozen=True)
class User:
    id: int
    name: str
    is_verified: bool


@dataclass(frozen=True)
class Order:
    id: int
    user_id: int
    amount: float
    is_paid: bool

class VerifiedUserProof:
    def __init__(self, user: User):
        if not user.is_verified:
            raise ValueError(
                f"User {user.id} is not verified"
            )
        self.user = user

class VerifiedUser(Sigma):
    def __init__(
        self,
        user: User,
        proof: VerifiedUserProof
    ):
        super().__init__(
            domain=User,
            codomain=lambda u: VerifiedUserProof,
            first=user,
            second=proof
        )

    @property
    def user(self) -> User:
        return self.first

PaidOrderData: TypeAlias = tuple[Order, VerifiedUser]

class PaidOrderProof:
    def __init__(self, data: PaidOrderData):
        order, verified_user = data
        user = verified_user.user

        if not order.is_paid:
            raise ValueError(
                f"Order {order.id} is not paid"
            )

        if order.user_id != user.id:
            raise ValueError(
                f"Order {order.id} does not belong to user {user.id}"
            )

        self.order = order
        self.verified_user = verified_user

class PaidOrder(Sigma):
    def __init__(
        self,
        data: PaidOrderData,
        proof: PaidOrderProof
    ):
        super().__init__(
            domain=tuple,
            codomain=lambda c: PaidOrderProof,
            first=data,
            second=proof
        )

    @property
    def order(self) -> Order:
        return self.first[0]

    @property
    def verified_user(self) -> VerifiedUser:
        return self.first[1]



user = User(
    id=1,
    name="Andrey",
    is_verified=True
)

verified_user = VerifiedUser(
    user=user,
    proof=VerifiedUserProof(user)
)

order = Order(
    id=100,
    user_id=user.id,
    amount=1500,
    is_paid=True
)

paid_order_data: PaidOrderData = (
    order,
    verified_user
)

paid_order = PaidOrder(
    data=paid_order_data,
    proof=PaidOrderProof(paid_order_data)
)

