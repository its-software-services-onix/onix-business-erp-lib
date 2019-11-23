#!/bin/bash
 
coverlet ./OnixBusinessErpTest/bin/Debug/netcoreapp3.0/OnixBusinessErpTest.dll --target "dotnet" --targetargs "test . --no-build" --format lcov
