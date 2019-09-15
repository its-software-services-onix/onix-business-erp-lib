#!/bin/bash
coverlet ./OnixBusinessErpTest/bin/Debug/netcoreapp2.2/OnixBusinessErpTest.dll --target "dotnet" --targetargs "test . --no-build" --format lcov
