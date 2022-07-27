const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/device"
    ],
    target: "https://localhost:7020",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
