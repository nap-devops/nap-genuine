<?php
$iv = chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0);

#$result = openssl_decrypt(base64_decode('I3wyaWwjQxLQUxiH0aPC3w=='), 'AES-256-CBC', 'nRDk3WHJTuPPBMwD', OPENSSL_RAW_DATA, $iv);
$result =  openssl_decrypt(base64_decode('2cBLjJxZmpFR0eUZrexu+lTU39EfUB3pmT5vdUyU5XltASuvlSE4+yYtjp7GB9QE'), 'AES-256-CBC', 'nRDk3WHJTuPPBMwD', OPENSSL_RAW_DATA, $iv);

echo "$result";
?>