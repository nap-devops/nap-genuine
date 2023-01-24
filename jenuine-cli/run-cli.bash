#!/bin/bash

#./run-cli.bash job --action=GetJobs --data=data/assets-query.json

. ./export-dev.bash

export backend__user=${USER}
export backend__password=${PASSWORD}
export backend__url=${URL}

dotnet run -- $*
