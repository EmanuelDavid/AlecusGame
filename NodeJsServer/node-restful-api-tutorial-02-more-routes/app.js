const express = require('express');
const app = express();

const alecuRoutes = require('./api/routes/alecu');

app.use('/alecu', alecuRoutes);


module.exports = app;