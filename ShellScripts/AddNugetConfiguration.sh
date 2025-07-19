#!/bin/bash

helpFunction() {
  echo "Usage: $0 [options]"
  echo "Options:"
  echo "  -t, --token         GitHub API token (required)"
}

while getopts "t::h" opt; do
  case $opt in
    t)
      token=$OPTARG
      ;;
    h | \?)
      helpFunction
      exit 0
      ;;
  esac
done

# Check if the required options are provided
if [ -z "$token" ]; then
  echo "Error: GitHub API token is required."
  helpFunction
  exit 1
fi

# Create the output directory if it doesn't exist
dotnet new nugetconfig --force

# Add the GitHub package source
dotnet nuget add source "https://nuget.pkg.github.com/tranthaibinh111/index.json" \
  --name "GitHub" \
  --username "tranthaibinh111" \
  --password "$token" \
  --store-password-in-clear-text \
  --configfile "nuget.config"

echo "NuGet configuration file created with GitHub package source added."
