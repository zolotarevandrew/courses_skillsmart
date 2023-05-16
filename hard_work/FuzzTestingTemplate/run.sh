./afl/afl-fuzz \
		-i testcases/"$TARGET_FUNCTION" \
		-o findings \
		-t 5000 \
		-m 10000 \
		out/FuzzTestingTemplate "$TARGET_FUNCTION"