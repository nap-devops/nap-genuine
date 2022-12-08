#!/bin/bash

HOST="james:ThisxIsPassw0rd@localhost:5001" # for local DB only
HOST="*****:****@api.genuine-dev.napbiotec.io"

id=$(shuf -i 1-100000 -n 1)

#--request POST \

# To add new asset
curl --header "Content-Type: application/json" \
-k -v \
--data "{\"ProductId\":\"abcxyz-hygkd-${id}\", \"AssetId\":\"xxxxx-${id}\", \"PinNo\": \"pin-00000002\", \"SerialNo\": \"serial-0000002\", \"IsRegistered\": \"false\", \"AssetName\": \"ss\"}" \
https://${HOST}/api/assets/org/napbiotec/action/AddAsset
