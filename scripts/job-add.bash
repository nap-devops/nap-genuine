#!/bin/bash

. ./export.bash

HOST="${USER_PASSWORD}@api.genuine-dev.napbiotec.io"

id=$(shuf -i 1-100000 -n 1)

#--request POST \

curl --header "Content-Type: application/json" \
-k -v \
--data @"job.json" \
https://${HOST}/api/jobs/org/napbiotec/action/ExportAssets

#https://${HOST}/api/jobs/org/napbiotec/action/ExportAssets

#https://${HOST}/api/jobs/org/napbiotec/action/CreateAssets
