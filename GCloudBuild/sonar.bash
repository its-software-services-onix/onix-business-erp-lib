#!/bin/bash

#Be careful to set this file without \r

WORK_DIR=/OnixBusinessErp
SOLUTION_DIR=$WORK_DIR/onix-business-erp

mkdir -p ${WORK_DIR}
cd ${WORK_DIR}
git clone https://github.com/pjamenaja/onix-business-erp.git
cd ${SOLUTION_DIR}
git checkout ${COMMIT_SHA} -b ${COMMIT_SHA}

dotnet sonarscanner begin \
    /key:pjamenaja_onix-business-erp \
    /o:pjamenaja \
    /v:${BUILT_VERSION} \
    /d:sonar.host.url=https://sonarcloud.io \
    /d:sonar.branch.name=${BRANCH_NAME} \
    /d:sonar.cs.opencover.reportsPaths=./coverage.opencover.xml \
    /d:sonar.javascript.exclusions=**/bootstrap/**,**/jquery/**,**/jquery-validation/**,**/jquery-validation-unobtrusive/** \
    /d:sonar.verbose=true \
    /d:sonar.scm.provider=git \
    /d:sonar.leak.period=${BASELINE_VERSION} \
    /d:sonar.login=${SONAR_KEY}

dotnet build OnixBusinessErp.sln

coverlet './OnixBusinessErpTest/bin/Debug/netcoreapp2.2/OnixBusinessErpTest.dll' --target 'dotnet' --targetargs 'test . --no-build' --format opencover
if [ "$?" -ne "0" ]; then
  echo "Exit code from coverlet is not zero!!!"
  exit 1
fi

dotnet sonarscanner end /d:sonar.login=${SONAR_KEY}