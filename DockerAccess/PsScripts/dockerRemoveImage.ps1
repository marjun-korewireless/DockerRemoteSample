#Script to remove an image forcefully
param(
   [Parameter(Position=0)]
   $image
)
docker rmi -f $image