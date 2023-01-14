#!/bin/bash

HOST="james:ThisxIsPassw0rd@localhost:5001"
#HOST=api.genuine-dev.napbiotec.io

id=$(shuf -i 1-100000 -n 1)

#--request POST \

curl --header "Content-Type: application/json" \
-k -v \
--data @"job.json" \
https://${HOST}/api/jobs/org/napbiotec/action/ExportAssets

#https://${HOST}/api/jobs/org/napbiotec/action/CreateAssets
