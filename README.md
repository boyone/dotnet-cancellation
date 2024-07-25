# Cancellation

## WeatherForecastWithoutCancellation

- cancel by user: run following command and then press `control-C`

```shell
curl -X 'GET' \
  'http://localhost:5189/WeatherForecastWithoutCancellation' \
  -H 'accept: application/json'
```

- cancel by set timeout

```shell
curl -X 'GET' --max-time 1 \
  'http://localhost:5189/WeatherForecastWithoutCancellation' \
  -H 'accept: application/json'
```

## WeatherForecastWithCancellation

- cancel by user: run following command and then press `control-C`

```shell
curl -X 'GET' \
  'http://localhost:5189/WeatherForecast' \
  -H 'accept: application/json'
```

- cancel by set timeout

```shell
curl -X 'GET' --max-time 1 \
  'http://localhost:5189/WeatherForecast' \
  -H 'accept: application/json'
```
