FROM mongo
COPY mongo-init.js /docker-entrypoint-initdb.d/

ENV MONGO_INITDB_ROOT_USERNAME root
ENV MONGO_INITDB_ROOT_PASSWORD ppgm2021
ENV MONGO_INITDB_DATABASE ppgm-db

EXPOSE 27017
# RUN ["/usr/local/bin/docker-entrypoint.sh]
