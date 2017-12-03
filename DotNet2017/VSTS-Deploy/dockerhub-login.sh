#!/bin/bash

echo $2 | docker login -u $1 --password-stdin 