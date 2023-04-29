#!/bin/bash

PRODUCT1=ALDAMEX-CINNAFACT-E-10ML

ORG=aldamex
DATA_DIR=data-import/${ORG}
PRODUCT_ID=${PRODUCT1}

cp ${DATA_DIR}/product-add-template.json ${DATA_DIR}/product-add.json
sed -i "s#__GENERATED_PRODUCT_ID__#${PRODUCT_ID}#g" ${DATA_DIR}/product-add.json

./run-cli.bash product --action=AddProduct --data=${DATA_DIR}/product-add.json

cp ${DATA_DIR}/jobs-create-assets-template.json ${DATA_DIR}/jobs-create-assets.json
sed -i "s#__GENERATED_PRODUCT_ID__#${PRODUCT_ID}#g" ${DATA_DIR}/jobs-create-assets.json

./run-cli.bash job --action=CreateAssets --data=${DATA_DIR}/jobs-create-assets.json
