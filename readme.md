### Pre-build requirements
Required system ingredients:
- dotnet 6

### Build
`dotnet build -o bin`

### Run
Example run: 
`./bin/gist-bookstack-exporter --tokenId <bookstack_api_tokenid> --tokenSecret <bookstack_api_tokensecret> --url <bookstack_base_url> --book "My gists" --gist 01c72541cf384ed3c07154d6dbf2973d`

### Docker

Build: 
`docker build --no-cache --tag gist-bookstack-exporter .`

Run:
`docker run --rm gist-bookstack-exporter:latest --tokenId <bookstack_api_tokenid> --tokenSecret <bookstack_api_tokensecret> --url <bookstack_base_url> --book "My gists" --gist 01c72541cf384ed3c07154d6dbf2973d`

### Bash alias (Linux)
Add below line to the ~/.profile file: 
`alias gbe="docker run --rm gist-bookstack-exporter:latest"` 
and run `source ~/.profile`

So right now you can run the app with that command: 
`gbe --tokenId <bookstack_api_tokenid> --tokenSecret <bookstack_api_tokensecret> --url <bookstack_base_url> --book "My gists" --gist 01c72541cf384ed3c07154d6dbf2973d`
