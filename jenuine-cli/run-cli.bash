#!/bin/bash

#./run-cli.bash asset --action=GetAssets --data=data/assets-query.json
#./run-cli.bash asset --action=GetAssetsCount --data=data/assets-query.json
#./run-cli.bash asset --action=GetAssetById --id=63ba4bc02c73d154cca0e371
#./run-cli.bash asset --action=AddAsset --data=data/assets-add.json
#./run-cli.bash asset --action=DeleteAssetById --id=63d229be680cc279f4f5cce4
#./run-cli.bash asset --action=UpdateAssetById --id=63ba4ae63e0e99fd4847daae --data=data/assets-update.json
#./run-cli.bash asset --action=UpdateAssetRegisterFlagById --id=63ba4ae63e0e99fd4847daae --data=data/assets-update.json
#./run-cli.bash asset --action=RegisterAsset --serial=ABCIXIYSK --pin=091879007
#./run-cli.bash asset --action=RegisterAssetRedirect --serial=ABCIXIYSK --pin=091879007

#./run-cli.bash job --action=GetJobs --data=data/jobs-query.json
#./run-cli.bash job --action=GetJobsCount --data=data/jobs-query.json
#./run-cli.bash job --action=CreateAssets --data=data/jobs-create-assets.json
#./run-cli.bash job --action=ExportAssets --data=data/jobs-export-assets.json
#./run-cli.bash job --action=GetJobById --id=63c28a1b0f6189ad9bf9d2d3
#./run-cli.bash job --action=DeleteJobById --id=63c28a1b0f6189ad9bf9d2d3
#./run-cli.bash job --action=UpdateJobStatusById --id=63c27808451a4f65bd83ce94 --data=data/jobs-update.json
#./run-cli.bash job --action=UpdateJobProgressById --id=63c27808451a4f65bd83ce94 --data=data/jobs-update.json

#./run-cli.bash product --action=GetProducts --data=data/products-query.json
#./run-cli.bash product --action=GetProductsCount --data=data/products-query.json
#./run-cli.bash product --action=AddProduct --data=data/products-add.json
#./run-cli.bash product --action=DeleteProductById --id=63d0aa043b537043c3080073
#./run-cli.bash product --action=UpdateProductById --id=638b1fad415438d07a5b9d51 --data=data/products-update.json
#./run-cli.bash product --action=GetProductById --id=638b1fad415438d07a5b9d51

. ./export-local.bash

export backend__user=${USER}
export backend__password=${PASSWORD}
export backend__url=${URL}

dotnet run -- $*
