from dataclasses import dataclass
import time
from typing import Callable, Dict, List, Tuple
from pymonad.state import State
from pymonad.tools import curry


Substitution = Tuple[str, str]
ExecutionMetric = Dict[str, float]

@dataclass(frozen=True)
class SubstitutionBuildRequest:
    key: str

@dataclass(frozen=True)
class ProviderSubstitutionBuildRequest(SubstitutionBuildRequest):
    provider_id: int

@dataclass(frozen=True)
class CommonSubstitutionBuildRequest(SubstitutionBuildRequest):
    pass

class SubstitutionBuilder:
    def __init__(self, name: str):
        self.name = name

    def build(self, request: SubstitutionBuildRequest) -> List[Substitution]:
        raise NotImplementedError

class ProviderSubstituionBuilder(SubstitutionBuilder):
    def __init__(self):
        super().__init__("ProviderSubstituionBuilder")

    def build(self, request: ProviderSubstitutionBuildRequest) -> List[Substitution]:
        time.sleep(0.050)
        return [
            ("PROVIDER_CODE", f"{request.provider_id}"),
            ("PROVIDER_NAME", "Name"),
        ]
    
class CommonSubstituionBuilder(SubstitutionBuilder):
    def __init__(self):
        super().__init__("CommonSubstituionBuilder")

    def build(self, request: CommonSubstitutionBuildRequest) -> List[Substitution]:
        return [
            ("COMMON_ITEM", f"test"),
        ]
    
@curry(3)
def timed_build(builder: SubstitutionBuilder, request: SubstitutionBuildRequest, substitutions: List[Substitution]):
    def with_timings(metrics: ExecutionMetric):
        start = time.perf_counter()
        new_substitutions = builder.build(request)
        elapsed = time.perf_counter() - start

        updated = dict(metrics)
        updated[request.key] = updated.get(request.key, 0.0) + elapsed
        return substitutions + new_substitutions, updated

    return State(with_timings)
    
if __name__ == "__main__":

    provider_builder = ProviderSubstituionBuilder()
    common_builder = CommonSubstituionBuilder()

    pipeline = (
        State.insert([])
        .then(timed_build(provider_builder, ProviderSubstitutionBuildRequest(key="provider:42", provider_id=42)))
        .then(timed_build(common_builder,CommonSubstitutionBuildRequest(key="commmon")))
    )
    substitutions, metrics = pipeline.run({})

    print(substitutions)
    print(metrics)
    
