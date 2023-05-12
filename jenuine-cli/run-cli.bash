#!/bin/bash

#./run-cli.bash coa_spec --action=GetCoaSpec --data=data/coa-spec-query.json
#./run-cli.bash coa_spec --action=AddCoaSpec --data=data/coa-spec-add.json
#./run-cli.bash coa_spec --action=UpdateCoaSpecById --data=data/coa-spec-update.json --id=645cf490ef147d961b9d026b
#./run-cli.bash coa_spec --action=GetCoaSpecCount --data=data/coa-spec-query.json
#./run-cli.bash coa_spec --action=DeleteCoaSpecById --id=645cf421ef147d961b9d026a
#./run-cli.bash coa_spec --action=GetCoaSpecById --id=645cf490ef147d961b9d026b

#./run-cli.bash coa_criteria_group --action=GetCoaCriteriaGroup --data=data/coa-criteria-group-query.json
#./run-cli.bash coa_criteria_group --action=AddCoaCriteriaGroup --data=data/coa-criteria-group-add.json
#./run-cli.bash coa_criteria_group --action=DeleteCoaCriteriaGroupById --id=645c41e83752070e1263feb3
#./run-cli.bash coa_criteria_group --action=GetCoaCriteriaGroupCount --data=data/coa-criteria-group-query.json
#./run-cli.bash coa_criteria_group --action=UpdateCoaCriteriaGroupById --id=645c44953752070e1263feb6 --data=data/coa-criteria-group-update.json

#./run-cli.bash coa_criteria --action=GetCoaCriteria --data=data/coa-criteria-query.json
#./run-cli.bash coa_criteria --action=AddCoaCriteria --data=data/coa-criteria-add.json
#./run-cli.bash coa_criteria --action=GetCoaCriteriaCount --data=data/coa-criteria-query.json
#./run-cli.bash coa_criteria --action=UpdateCoaCriteriaById --id=645c76c5236a1d00d5594d21 --data=data/coa-criteria-update.json
#./run-cli.bash coa_criteria --action=DeleteCoaCriteriaById --id=645c792c236a1d00d5594d22


#./run-cli.bash customer --action=GetCustomers --data=data/customers-query.json
#./run-cli.bash customer --action=GetProductsCount --data=data/products-query.json
#./run-cli.bash customer --action=AddProduct --data=data/products-add.json
#./run-cli.bash customer --action=DeleteProductById --id=63d0aa043b537043c3080073
#./run-cli.bash customer --action=GetProductByGeneratedId --id=abcxyz-hygkd-13500
#./run-cli.bash customer --action=UpdateProductById --id=638b1fad415438d07a5b9d51 --data=data/products-update.json
#./run-cli.bash customer --action=GetProductById --id=638b1fad415438d07a5b9d51

#./run-cli.bash config --action=GetConfigs --data=data/configs-query.json
#./run-cli.bash config --action=AddConfig --data=data/configs-add.json
#./run-cli.bash config --action=UpdateConfigById --id=63d9a46f393d3afc4d707697 --data=data/configs-update.json

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
#./run-cli.bash product --action=GetProductByGeneratedId --id=abcxyz-hygkd-13500
#./run-cli.bash product --action=UpdateProductById --id=638b1fad415438d07a5b9d51 --data=data/products-update.json
#./run-cli.bash product --action=GetProductById --id=638b1fad415438d07a5b9d51

. ./export-dev.bash

export backend__organization=napbiotec
export backend__user=${USER}
export backend__password=${PASSWORD}
export backend__url=${URL}

dotnet run -- $*
