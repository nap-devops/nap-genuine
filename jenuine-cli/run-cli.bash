#!/bin/bash

#./run-cli.bash job --action=GetJobs --data=data/jobs-query.json
#./run-cli.bash job --action=GetJobsCount --data=data/jobs-query.json
#./run-cli.bash job --action=CreateAssets --data=data/jobs-create-assets.json
#./run-cli.bash job --action=ExportAssets --data=data/jobs-export-assets.json
#./run-cli.bash product --action=GetProducts --data=data/products-query.json
#./run-cli.bash product --action=GetProductsCount --data=data/products-query.json
#./run-cli.bash product --action=AddProduct --data=data/products-add.json
#./run-cli.bash product --action=DeleteProductById --id=63d0aa043b537043c3080073
#./run-cli.bash product --action=UpdateProductById --id=638b1fad415438d07a5b9d51 --data=data/products-update.json
#./run-cli.bash product --action=GetProductById --id=638b1fad415438d07a5b9d51

. ./export-dev.bash

export backend__user=${USER}
export backend__password=${PASSWORD}
export backend__url=${URL}

dotnet run -- $*
