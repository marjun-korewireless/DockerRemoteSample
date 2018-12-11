#Stop a running container
param(
	[Parameter(Position=0)]
	$container
)
docker stop $container