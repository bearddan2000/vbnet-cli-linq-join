# vbnet-cli-linq-join

## Description
A vb.net using LINQ to filter
a list of food objects by calories
joining to a ratings table to create
a new review object.
VB.Net is NOT well supported on linux
so the source code could not be compiled
as part of the build an executable
was supplied.

## Tech stack
- bash
- vb.net
  - Framework 4.7
- mono 6.8

## Docker stack
- docker-cli
- ubuntu:20.04

## Requirements
Docker desktop must be installed and the application
being called must be linux compatiple.

## To run
`sudo ./install.sh -u`

## To stop (optional)
`sudo ./install.sh -d`

## To see help
`sudo ./install.sh -h`
