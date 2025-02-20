from datetime import datetime, timezone

# Local Date
date = datetime.now()
print(date)

# UTC Date
date = datetime.now(timezone.utc)
print(date)

# ISO 8601
date = datetime.now(timezone.utc).astimezone()
print(date)