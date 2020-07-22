## Welcome all! 
Please read below instruction thoroghly before starting your task.

## Docker for running the website
[docker-compose](http://git.mvp.studio/talent-group/talent-docker)

## Coding Standard & Notice
As we're working as a team, we should always consider others. Therefore, this is the coding standard everyone should follow.
https://www.dofactory.com/reference/csharp-coding-standards

- Excel Reader
After you add a new excel in the project, you need to follow the instructions in ExcelUtil.cs to access the data.
* Populate the data into memory.
* Call the SetDataSource method in the constructor of the class that you are using.
* Access data by the key.
Type "///" to do the documents of your methods in the extension file.
- Error Handling
- Use "throw new Exception()" to handle errors instead of assertions.
- Use assertions for internal logic checks within your code, and normal exceptions for error conditions outside your immediate code's control.
- Naming conventions
- Please follow this article to name your classes/methods/elements properly.
- https://www.c-sharpcorner.com/UploadFile/8a67c0/C-Sharp-coding-standards-and-naming-conventions/
- MUST not to use "Thread.Sleep()" in your codes.
- Avoid hardcoding issues
- Use "var" instead of the specific type.
- Don't create a new feature file when it can be considered to be a part of an existed feature.
Eg. UpdateProfile can be a scenario of Profile.feature, so don't need to create UpdateProfile.feature
Make use of existed functions
- Try not to create your own functions but use existed functions, like login or the methods in the extension file.

## Comments
Comments are compulsory. There are 2 types of comment that we like you to document down. The first would be the comment where you explain what the line of code does. The second would be the documentationi comment, you can view the example here:https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments

## Branch
- You can create your own branch in Visual Studio. Go -> team explorer -> home -> branches -> new branch -> rename the branch as TC-xxx/yyyy’ where x is the issue number(TC-xxx) and y is the name of feature you’re testing. PLEASE DO NOT INCLUDE YOUR NAME HERE. After that, you will be check-in at the new branch and you can start working on it.
- Rename the branch as TC-xxx/yyyy’ where x is the issue number(tc-xxx) and y is the name of feature you’re testing. PLEASE DO NOT INCLUDE YOUR NAME HERE and follow the EXACT nameing format.
- If you're starting a new task, please update your `local master` with `origin/master` before creating a new local branch. Otherwise if you create a new branch from the local master , all of your code are few commit behind the origin/master . And by the time you finish your task, you will have about 50+ commit behind the origin/master which makes very difficult for merging

While you are working on the task, make sure you commit the task as often as you can.(Do not commit your first commit as 'init commit', make sure it's meaningful) Once you finish the task, commit the task to the remote server, and you can send the pull request in GitLab.(select your branch and click Merge request). Meanwhile, you can start with different tasks.

# Q&A
### Q: After we finish one test case and create another branch, should we pull the newest version from the master or clone one more time?
A: After finish a test in a branch, push the changes to the repo, you can switch back to master branch and sync your local master with origin master to see get the latest update if any.
After that, you can create another new branch from your local master(latest version) and to work on it.

### Q: Can I see other branches in Visual Studio?
A: Yes, go to team explore and select the branch button. You will see list of remote branches under the origin folder. If you cannot see the origin branches, you can try to sync your local branch with the origin again.
