#!/bin/bash

#./run-cli.bash job --action=GetJobs --data=data/assets-query.json
#./run-cli.bash job --action=CreateAssets --data=data/jobs-create-assets.json
#./run-cli.bash job --action=ExportAssets --data=data/jobs-export-assets.json
#./run-cli.bash product --action=GetProducts --data=data/products-query.json
#./run-cli.bash product --action=AddProduct --data=data/products-add.json
#./run-cli.bash product --action=DeleteProductById --id=63d0aa043b537043c3080073

. ./export-dev.bash

export backend__user=${USER}
export backend__password=${PASSWORD}
export backend__url=${URL}

dotnet run -- $*
