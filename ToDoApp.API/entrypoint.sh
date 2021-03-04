#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:80"

until dotnet ef database update; do
>&2 echo "SQL SERVER I STARTING UP"
sleep 2
done

>&2 echo "SQL server is up"
exec $run_cmd