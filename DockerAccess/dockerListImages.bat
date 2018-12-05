::list docker images
@echo off
docker images --format "table {{.ID}}\t{{.Repository}}\t{{.Tag}}\t\t{{.CreatedAt}}"