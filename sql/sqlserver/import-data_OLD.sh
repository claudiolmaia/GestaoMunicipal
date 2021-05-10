#aguardando 90 segundos para aguardar o provisionamento e start do banco
sleep 60
#rodar o comando para criar o banco
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "@ppgm2021" -i db.sql
