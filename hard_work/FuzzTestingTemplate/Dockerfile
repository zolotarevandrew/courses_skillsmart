FROM ubuntu:16.04 AS build-env

RUN apt-get update && apt-get install -y curl build-essential

WORKDIR /app
RUN curl -LO http://lcamtuf.coredump.cx/afl/releases/afl-latest.tgz
RUN tar -xvf afl-latest.tgz

RUN curl -LO https://github.com/Metalnem/libfuzzer-dotnet/releases/latest/download/libfuzzer-dotnet.tar.gz
RUN tar -xvf libfuzzer-dotnet.tar.gz

WORKDIR afl-2.52b
RUN make

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app

ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install --global SharpFuzz.CommandLine

COPY FuzzTestingTemplate.csproj ./
RUN dotnet restore -r linux-x64

COPY Program.cs ./
RUN dotnet publish -r linux-x64 --self-contained --no-restore -c release -o out

COPY --from=build-env /app/afl-2.52b ./afl/
COPY --from=build-env /app/libfuzzer-dotnet ./libFuzzer/

COPY run.sh ./
COPY TestCases ./testcases/

ENV AFL_SKIP_BIN_CHECK=true
ENV SHARPFUZZ_PRINT_INSTRUMENTED_TYPES=true
ENV AFL_NO_FORKSRV=1

VOLUME /app/findings

CMD /bin/bash ./run.sh