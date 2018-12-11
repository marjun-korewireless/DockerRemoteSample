#Script to pull an image
param(
   [Parameter(Position=0)]
   $image
)
docker pull $image