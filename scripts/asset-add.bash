#!/bin/bash

HOST="james:ThisxIsPassw0rd@localhost:5001" # for local DB only
#HOST="*****:****@api.genuine-dev.napbiotec.io"

id=$(shuf -i 1-100000 -n 1)

#--request POST \

# To add new asset
curl --header "Content-Type: application/json" \
-k -v \
--data "{\"ProductId\":\"63968760e6749f71564e8fcb\", \"AssetId\":\"xxxxx-${id}\", \"PinNo\": \"pin-a0000003\", \"SerialNo\": \"serial-b000003\", \"IsRegistered\": \"false\", \"AssetName\": \"ss\"}" \
https://${HOST}/api/assets/org/napbiotec/action/AddAsset
