::list docker containers
@echo off
docker images --format "table {{.ID}}\t{{.Tag}}\t\t{{.CreatedAt}}"