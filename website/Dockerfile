FROM node:argon

# Create app directory
RUN mkdir -p /code
WORKDIR /code

# Bundle app source
COPY . /code

RUN npm install

EXPOSE 8000
CMD [ "npm", "start" ]
