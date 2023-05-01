#!/bin/bash

if [ -d "/home/coder/project/workspace/angularapp" ]
then
    echo "project folder present"
    cp /home/coder/project/workspace/karma/karma.conf.js /home/coder/project/workspace/angularapp/karma.conf.js;
    # checking for app component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/admin" ]
    then
        cp /home/coder/project/workspace/karma/admin.component.spec.ts /home/coder/project/workspace/angularapp/src/app/admin/admin.component.spec.ts;
    else
        echo "test_case1 FAILED";
    fi

    # checking for admin component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/user" ]
    then
        cp /home/coder/project/workspace/karma/appointment.component.spec.ts /home/coder/project/workspace/angularapp/src/app/user/components/appointment/appointment.component.spec.ts;
    else
        echo "test_case2 FAILED";
    fi

    # checking for login component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/admin" ]
    then
        cp /home/coder/project/workspace/karma/centerprofile.component.spec.ts /home/coder/project/workspace/angularapp/src/app/admin/components/centerprofile/centerprofile.component.spec.ts;
    else
        echo "test_case3 FAILED";
    fi

    # checking for user component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/user" ]
    then
        cp /home/coder/project/workspace/karma/login.component.spec.ts /home/coder/project/workspace/angularapp/src/app/user/components/login/login.component.spec.ts;
    else
        echo "test_case4 FAILED";
    fi

    # checking for home component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/user" ]
    then
        cp /home/coder/project/workspace/karma/signup.component.spec.ts /home/coder/project/workspace/angularapp/src/app/user/components/signup/signup.component.spec.ts;
    else
        echo "test_case5 FAILED";
    fi

    cd /home/coder/project/workspace/angularapp/;
    npm test;
else   
    echo "test_case1 FAILED";
    echo "test_case2 FAILED";
    echo "test_case3 FAILED";
    echo "test_case4 FAILED";
    echo "test_case5 FAILED";

fi
