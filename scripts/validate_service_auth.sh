#!/bin/bash
set -e

SERVICE_NAME="taskverse-auth"

echo "===== VALIDATE SERVICE ====="

echo "Checking if ${SERVICE_NAME} is running..."

systemctl is-active --quiet ${SERVICE_NAME}.service

echo "${SERVICE_NAME} service is running."

exit 0