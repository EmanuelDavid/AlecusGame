const express = require('express');
const router = express.Router();

router.post('/CheckIfCorrect', (req, res, next) => {

    res.status(200).json({
        // response: login()
        response: req.body.json
    });
});

function login() {
    return false;
    }

module.exports = router;