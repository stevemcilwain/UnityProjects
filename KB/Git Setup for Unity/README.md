# Git Setup for Unity Projects



## Ignore Files

To avoid committing files that should not be tracked with Git, include the .gitignore file from this repo in the root of your Unity project folder. 

You can also download the latest from: https://github.com/github/gitignore/blob/main/Unity.gitignore

The paths are relative to the Unity root director. If you place this .gitignore somewhere else then it will not properly exclude anything.



## Store Binary Files in LFS

When you commit binary files, such as images or 3D models to source control then every change re-commits the entire file. This can quickly grow the size of the repository.

Instead, binary files can be redirected to being stored in LFS and the pointers to those files are tracked with the commits. 

To enable ensure you have Git LFS installed and add the .gitattributes file from this repo to your Unity project.

* https://git-lfs.github.com/



## Options for LFS

Most major source control providers offer support for Git LFS, but each has some pros and cons:

* **Github**: charges for Git LFS Data bandwidth, you get 1GB included free then have to upgrade by purchasing data packs

* **GitlLb**: Git LFS storage is included in the base storage allowed for your tier, exceeding that requires purchasing add-on or upgrading

* **Azure DevOps**: Unlimited Git LFS storage for both public and private repos.






