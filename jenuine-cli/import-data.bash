#!/bin/bash

ORG=napbiotec
DATA_DIR=data-import/${ORG}
PRODUCT_ID=DEMO-00001-LOT-00001

./run-cli.bash config --action=AddConfig --data=${DATA_DIR}/configs-add.json

cp ${DATA_DIR}/product-add-template.json ${DATA_DIR}/product-add.json
sed -i "s#__GENERATED_PRODUCT_ID__#${PRODUCT_ID}#g" ${DATA_DIR}/product-add.json

./run-cli.bash product --action=AddProduct --data=${DATA_DIR}/product-add.json

cp ${DATA_DIR}/jobs-create-assets-template.json ${DATA_DIR}/jobs-create-assets.json
sed -i "s#__GENERATED_PRODUCT_ID__#${PRODUCT_ID}#g" ${DATA_DIR}/jobs-create-assets.json

./run-cli.bash job --action=CreateAssets --data=${DATA_DIR}/jobs-create-assets.json
