FROM mysql:5.7
#ENV MYSQL_ROOT_PASSWORD=@ppgm2021
COPY db.sql /docker-entrypoint-initdb.d/

EXPOSE 3306

RUN ["/usr/local/bin/docker-entrypoint.sh"]
#, "mysqld", "--datadir", "/initialized-db"]

# FROM mysql:5.7
# COPY --from=builder /initialized-db /var/lib/mysql

