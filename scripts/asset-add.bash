#!/bin/bash

HOST="james:ThisxIsPassw0rd@localhost:5001"
#HOST=api.genuine-dev.napbiotec.io

id=$(shuf -i 1-100000 -n 1)

#--request POST \

curl --header "Content-Type: application/json" \
-k -v \
--data "{\"ProductId\":\"abcxyz-hygkd-${id}\", \"AssetId\":\"xxxxx-${id}\", \"PinNo\": \"12345670\", \"SerialNo\": \"sasddsssss\", \"IsRegistered\": \"false\", \"AssetName\": \"ss\"}" \
https://${HOST}/api/assets/org/napbiotec/action/AddAsset
